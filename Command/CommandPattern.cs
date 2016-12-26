using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Command
{
    public abstract class Command
    {
        public abstract void execute(Target target);

        public abstract void undo();

        public abstract void redo();

        public override abstract String ToString();
    }

    public class ShrinkSpell : Command
    {
        private Size oldSize;
        private Target target;

        public override void execute(Target target)
        {
            oldSize = target.size;
            target.size = Size.SMALL;
            this.target = target;
        }

        public override void undo()
        {
            if (oldSize != null && target != null)
            {
                Size temp = target.size;
                target.size = oldSize;
                oldSize = temp;
            }
        }

        public override void redo()
        {
            undo();
        }

        public override String ToString()
        {
            return "Shrink spell";
        }
    }

    public class InvisibilitySpell : Command
    {
        private Target target;

        public override void execute(Target target)
        {
            target.visibility = Visibility.INVISIBLE;
            this.target = target;
        }

        public override void undo()
        {
            if (target != null)
            {
                target.visibility = Visibility.VISIBLE;
            }
        }

        public override void redo()
        {
            if (target != null)
            {
                target.visibility = Visibility.INVISIBLE;
            }
        }

        public override String ToString()
        {
            return "Invisibility spell";
        }
    }

   

    public abstract class Target
    {
        public Size size;

        public Visibility visibility;

        public override abstract String ToString();

        public void printStatus(ITestOutputHelper output)
        {
            var status = $"{this}, [size={size}] [visibility={visibility}]";
            //LOGGER.info("{}, [size={}] [visibility={}]", this, getSize(), getVisibility());
            //Console.WriteLine(status);
            output.WriteLine(status);
        }
    }

    public class Goblin : Target
    {
        public Goblin()
        {
            size = Size.NORMAL;
            visibility = Visibility.VISIBLE;
        }

        public override String ToString()
        {
            return "Goblin";
        }
    }

    

    public enum Visibility
    {
        VISIBLE, INVISIBLE, UNDEFINED
    }

    public enum Size
    {
        SMALL, NORMAL, LARGE, UNDEFINED
    }

    public class Wizard
    {
        private Stack<Command> undoStack = new Stack<Command>();
        private Stack<Command> redoStack = new Stack<Command>();
        private ITestOutputHelper _output;

        public Wizard(ITestOutputHelper output)
        {
            _output = output;
        }

        /**
         * Cast spell
         */
        public void castSpell(Command command, Target target)
        {
            var msg = $"{this} casts {command} at {target}";
            //LOGGER.info("{} casts {} at {}", this, command, target);
            Console.WriteLine(msg);
            command.execute(target);
            undoStack.Push(command);
        }

        /**
         * Undo last spell
         */
        public void undoLastSpell()
        {
            if (undoStack.Any())
            {
                Command previousSpell = undoStack.Pop();

                redoStack.Push(previousSpell);
                var msg = $"{this} undoes {previousSpell}";
                _output.WriteLine(msg);
                //LOGGER.info("{} undoes {}", this, previousSpell);
                previousSpell.undo();
            }
        }

        /**
         * Redo last spell
         */
        public void redoLastSpell()
        {
            if (redoStack.Any())
            {
                Command previousSpell = redoStack.Pop();
                undoStack.Push(previousSpell);
                var msg = $"{this} redoes {previousSpell}";
                _output.WriteLine(msg);
                //LOGGER.info("{} redoes {}", this, previousSpell);
                previousSpell.redo();
            }
        }

        public override String ToString()
        {
            return "Wizard";
        }
    }

}

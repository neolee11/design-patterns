using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class RequestHandler
    {
        private RequestHandler next;
        
        public RequestHandler(RequestHandler next)
        {
            this.next = next;
        }

        public virtual void handleRequest(Request req)
        {
            if (next != null)
            {
                next.handleRequest(req);
            }
        }

        protected void printHandling(Request req)
        {
            var msg = $"{this} handling request {req}";
            Console.Out.WriteLine(msg);
        }

        public abstract override String ToString();
    }

    public enum RequestType
    {
        DEFEND_CASTLE, TORTURE_PRISONER, COLLECT_TAX
    }

    public class OrcKing
    {
        RequestHandler chain;

        public OrcKing()
        {
            buildChain();
        }

        private void buildChain()
        {
            chain = new OrcCommander(new OrcOfficer(new OrcSoldier(null)));
        }

        public void makeRequest(Request req)
        {
            chain.handleRequest(req);
        }

    }

    public class OrcCommander : RequestHandler
    {
        public OrcCommander(RequestHandler handler) : base(handler) { }

        public override void handleRequest(Request req)
        {
            if (req.getRequestType().Equals(RequestType.DEFEND_CASTLE))
            {
                printHandling(req);
                req.markHandled();
            }
            else
            {
                base.handleRequest(req);
            }
        }

        public override String ToString()
        {
            return "Orc commander";
        }
    }

    public class OrcOfficer : RequestHandler
    {
        public OrcOfficer(RequestHandler handler) : base(handler)
        {
        }

        public override void handleRequest(Request req)
        {
            if (req.getRequestType().Equals(RequestType.TORTURE_PRISONER))
            {
                printHandling(req);
                req.markHandled();
            }
            else
            {
                base.handleRequest(req);
            }
        }

        public override String ToString()
        {
            return "Orc officer";
        }

    }

    public class OrcSoldier : RequestHandler
    {
        public OrcSoldier(RequestHandler handler) : base(handler)
        {
        }

        public override void handleRequest(Request req)
        {
            if (req.getRequestType().Equals(RequestType.COLLECT_TAX))
            {
                printHandling(req);
                req.markHandled();
            }
            else
            {
                base.handleRequest(req);
            }
        }

        public override String ToString()
        {
            return "Orc soldier";
        }
    }

    public class Request
    {
        private RequestType requestType;

        private String requestDescription;

        /**
         * Indicates if the request is handled or not. A request can only switch state from unhandled to
         * handled, there's no way to 'unhandle' a request
         */
        private Boolean handled;

        /**
         * Create a new request of the given type and accompanied description.
         *
         * @param requestType        The type of request
         * @param requestDescription The description of the request
         */
        public Request(RequestType requestType, String requestDescription)
        {
            this.requestType = requestType;
            this.requestDescription = requestDescription;
        }

        /**
         * Get a description of the request
         *
         * @return A human readable description of the request
         */
        public String getRequestDescription()
        {
            return requestDescription;
        }

        /**
         * Get the type of this request, used by each person in the chain of command to see if they should
         * or can handle this particular request
         *
         * @return The request type
         */
        public RequestType getRequestType()
        {
            return requestType;
        }

        /**
         * Mark the request as handled
         */
        public void markHandled()
        {
            this.handled = true;
        }

        /**
         * Indicates if this request is handled or not
         *
         * @return <tt>true</tt> when the request is handled, <tt>false</tt> if not
         */
        public Boolean isHandled()
        {
            return this.handled;
        }

        public override String ToString()
        {
            return getRequestDescription();
        }

    }
}

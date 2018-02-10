using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with custom Exceptions *****\n");
            Car myCar = new Car("Rusty", 90);
            try
            {
                myCar.Accelerate(50);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
            }
            Console.ReadLine();
        }
    }

    [Serializable]
    internal class CarIsDeadException : Exception
    {
        private DateTime now;
        private string v;

        public CarIsDeadException()
        {
        }

        public CarIsDeadException(string message) : base(message)
        {
        }

        public CarIsDeadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CarIsDeadException(string message, string v, DateTime now) : this(message)
        {
            this.v = v;
            this.now = now;
        }

        protected CarIsDeadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public bool CauseOfError { get; internal set; }
        public bool ErrorTimeStamp { get; internal set; }
    }
}

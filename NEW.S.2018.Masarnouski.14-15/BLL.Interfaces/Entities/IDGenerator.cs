using BLL.Interfaces.Interface;
using System;


namespace BLL.Interfaces.Entities
{
    public class IDGenerator : IIDGenerator
    {
        int id;
        public IDGenerator()
        {
            id = 1;
        }

        public IDGenerator(int id)
        {
            Id = id;
        }

        private int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The id must be greater than or equal to 0.", nameof(Id));
                }

                id = value;
            }
        }
        public int GenerateId()
        {
            return id++;
        }
    }
}

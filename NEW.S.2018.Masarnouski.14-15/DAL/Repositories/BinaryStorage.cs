using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BinaryStorage:IStorage
    {
        string path;
        public BinaryStorage(string path)
        {
            this.path = path;
        }

        public string Path
        {
            get
            {
                return this.path;
            }

            private set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArithmeticException($"{nameof(value)} must be not empty");
                }

                this.path = value;
            }
        }
        public List<BankAccount> Load()
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            using (var writer = new BinaryWriter(stream))
            {
                List<BankAccount> LoadedAccountsList = new List<BankAccount>();
                var reader = new BinaryReader(stream);

                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string holderName = reader.ReadString();
                    string holderSurName = reader.ReadString();
                    decimal balance = reader.ReadDecimal();
                    int bonus = reader.ReadInt32();
                    AccountType type = (AccountType)reader.ReadInt32();

                    LoadedAccountsList.Add(new BankAccount(id, holderName, holderSurName, balance, type, bonus));
                }
                return LoadedAccountsList;
            }
        }

        public void Save(List<BankAccount> accountsList)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    foreach (var account in accountsList)
                    {
                        writer.Write(account.Id);
                        writer.Write(account.HolderName);
                        writer.Write(account.HolderSurName);
                        writer.Write(account.Balance);
                        writer.Write(account.Bonus);
                        writer.Write((int)account.Type);

                    }
                    writer.Flush();
                }
            }
        }
    }
}

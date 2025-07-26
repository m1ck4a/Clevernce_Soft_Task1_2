using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Task2_Server
{
    public class ServerTests
    {
        public ServerTests()
        {
            Server.AddToCount(-Server.GetCount());
        }

        [Fact]
        public void GetCount_ReturnsZero_Initially()
        {
            int result = Server.GetCount();

            Assert.Equal(0, result);
        }

        [Fact]
        public void AddToCount_IncrementsValue_Correctly()
        {
            Server.AddToCount(5);

            Assert.Equal(5, Server.GetCount());

            Server.AddToCount(3);

            Assert.Equal(8, Server.GetCount());
        }

        [Fact]
        public async Task ConcurrentReads_DoNotBlockEachOther()
        {
            const int numReaders = 10;
            var tasks = new Task[numReaders];

            for (int i = 0; i < numReaders; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        Server.GetCount();
                    }
                });
            }

            await Task.WhenAll(tasks);

            Assert.Equal(0, Server.GetCount());
        }
    }
}

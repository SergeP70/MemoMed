using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Services.Mock
{
    public class FrequenciesInMemoryService
    {
        private static List<Frequency> frequencies = new List<Frequency>
        {
            new Frequency {Name="Dagelijks"},
            new Frequency {Name="2-Dagelijks"},
            new Frequency {Name="3-Dagelijks"},
            new Frequency {Name="Wekelijks"},
            new Frequency {Name="Maandelijks"}
        };

        public async Task<Frequency> GetFrequencyById(int id)
        {
            await Task.Delay(0);
            return frequencies.FirstOrDefault(f => f.Id == id);
        }

    }
}

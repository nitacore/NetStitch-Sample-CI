using NetStitch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetStitch_Sample_CI
{
    public interface ISharedInterface : INetStitchContract
    {
        [Operation]
        ValueTask<int> TallyAsync
        (int[] array
#if !___server___
        , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)
#endif
        );

        //C#7
        [Operation]
        ValueTask<IList<(string id, int sum, int count)>> SumAsync(IList<(string id, int[] targets)> list
#if !___server___
        , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)
#endif
        );
    }
}

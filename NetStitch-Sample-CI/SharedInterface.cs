using NetStitch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetStitch_Sample_CI
{
    [NetStitchContract]
    public interface ISharedInterface
    {
        [NetStitch.Operation("2836ab3d-e0c1-4926-9d2a-cc7578610da8")]
#if !___server___
        Task<
#endif
        int
#if !___server___
        >
#endif
#if !___server___
        TallyAsync
#else
        Tally
#endif
        (int[] array
#if !___server___
        , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)
#endif
        );

        //C#7
        //IList<(string id, int sum, int count) Sum(IList<(string id, int[] array)> list);
        [NetStitch.Operation("2a447771-97e0-4f5a-a61a-ca1f7dae7a30")]
#if !___server___
        Task<
#endif
        IList<ValueTuple<string, int, int>>
#if !___server___
        >
#endif
#if !___server___
        SumAsync
#else
        Sum
#endif
        (IList<ValueTuple<string, int[]>> list
#if !___server___
        , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)
#endif
        );

    }
}

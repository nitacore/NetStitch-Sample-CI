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
        [Operation("6484ffe7-51dc-4a63-9e3f-3582a78d4117")]
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

    }
}

namespace aoc2022.Test;

public class Aoc20221203Tests
{
    [Fact]
    public void ConstructorTakesInput()
    {
        var aoc20221203 = new Aoc20221203(ExampleInput());
    }

    [Fact]
    public void RowsAreSplitIntoEqualLengthStrings()
    {
        var aoc20221203 = new Aoc20221203(ExampleInput());

        Assert.Equal(6, aoc20221203.SplitRows.Count);

        Assert.Equal("vJrwpWtwJgWr", aoc20221203.SplitRows[0].Item1);

        Assert.Equal("hcsFMMfFFhFp", aoc20221203.SplitRows[0].Item2);
    }

    [Fact]
    public void FindDuplicateForTheHalves()
    {
        var aoc20221203 = new Aoc20221203(ExampleInput());

        Assert.Equal('p', aoc20221203.Duplicates[0]);
        Assert.Equal('L', aoc20221203.Duplicates[1]);
        Assert.Equal('P', aoc20221203.Duplicates[2]);
        Assert.Equal('v', aoc20221203.Duplicates[3]);
    }

    [Fact]
    public void SumOfExampleDuplicates()
    {
        var aoc20221203 = new Aoc20221203(ExampleInput());

        Assert.Equal(157, aoc20221203.PrioritiesSum(aoc20221203.Duplicates));
    }

    [Fact]
    public void SumOfTaskDuplicates()
    {
        var aoc20221203 = new Aoc20221203(TaskInput());

        Assert.Equal(7872, aoc20221203.PrioritiesSum(aoc20221203.Duplicates));
    }

    [Fact]
    public void SumOfBadgePriorities()
    {
        var aoc20221203 = new Aoc20221203(TaskInput());

        Assert.Equal(2497, aoc20221203.FindBadgesSum());
    }

    private static string ExampleInput()
    {
        return @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
    }

    private static string TaskInput()
    {
        return @"tdltdtmhlRNCBcwmHr
WDzDPnvvGnsWLWpGJJHRzCCRZNBRrRwMNwHH
DsDsQnJDnWsJnJvrQDPJddgShFQhjljqhggbdbbt
LqvbLLTdvlfdqTLtbvDSRHPhHmRSnndHnHRM
jswsGgzwsNgNWNwGJzVrgSHnhHHDmShmmGShnMDPRn
JMNWzVwMpjpLpTfTLLTf
HnQBjMjPQmRMmJCmBPGSFTSVWcNNGQQGGGTV
dgstqdtsbwrzddvrvdwqzhrWSFllDSWGDWFGDNsDDWSTHT
gpqZwwzHZhwzMJBmfZnnJLCL
PJHbTPCmLdTtLtRtBvzBrWffft
hnpTqhMncpFDppDqqNVFVvWzvNWNvfBfzs
GwZccTpgnDSDDZQdCZbbClbCmm
bnZnRZZZRlpGBbfRJjBbMfhCHwfsHShschMsHCww
LqVtqVmtLQvVqqLTFFvLDMhDMpMhwMSLDhsDCH
mFQWtNggVQQgmdgpJGpnnZJjbWGBRZ
GsdGrGqvLZqWvWWdrPLdfvsvSJDDcQQhcTbFbTcCJLSJShcJ
wmBlnjwjgHSSDQjfDDfF
wggpmwmwNnMlHRpttRHmlPfWzdGvvvzrZWVvMrPvvZ
jvlvTvTvTvcqTdZrdnGlVfNgspslpfGGnM
BWQhQzQwmhwWHbWCSRMRgjpjVDDRgDgVffgV
zLHQSBWmLcjdPjLLLZ
BjjLnRzBnRmTSTBhpBmCjnLqNPGGVNZgNgLGddZVNVdf
wDDJJQJlJtHrlwFFPNGGfZbbbglgfPSf
tFQssvcDJtJcFcvwHtBmnSCvRmzzhpSCWvmC
GvPVvVHPgzPMcFvDHssdpCpsnpHnsj
gmhmSRZBJTTTmSBZhhrqSBLRCnsBjjnbjBdbdbbdnbjwwBsj
WlrgrRgJSgZSJJJTZRtvVzvGtfzcVFcMzlGM
QSZwwsBZZwjsndFsMPHLzTLLLz
tpJfgHghmvqpNWrrTMrMMRzPrMPJ
ghgghmlvmgNWgmWwBQcbGGSclGHjjb
lhlnWGGFWZhDfgFfWDfrhgrRwcccqcZQBQMwcqJMTMRMqJ
jVdpSLPVSjtNdjdPtptzLNPPzcBzwCQrCcTBTRqwwqMCJTcC
PNHdpPLHtHtjdLghnHWvrvnFlFnf
qttvqPdCtLrqRgfpgpMgSfSWvM
TJccnTDjjDlDhSpfHdhpTpZf
wldwmJdwmsstCsLzBsBCGP
ddpCGpGpnndnpWqdVVpDGfDGFzSsFSZzBJShJsVtTstssrsr
jbvPLwFjztJBtvJz
wjggcgPFLlLwPFNwHmNPQqDRQfCRGCGqnpcRqQnn
PmmGhLLcgZbPQnqH
DlVsvvrvvvrsDJLRDvvCHbpBqpnbQnggbWZbggVW
vJRTSSRJClCCDwTJRfSfCsGzMLmGmzmjGcfmdFNNNtfh
vcmmMvfctfjLjvvRbLdHSnQSgQFnghSgQQSSjT
WzVbszVNHnTsQFgZ
pVlGlzrbDNrDrPpJNNJpVdBDvLdqvvvqqdBqcfvLdq
gfzgzPDVZQDDSqBdtFfdFdvqBB
MrwmTcJJsMwNmJdvFqdFGGtvvsGt
HMmTTwcJqcrTHrjjczhZQgzghgQHhnhhHh
BffBVgjPwPPPJwBBVJfDDsgrdZdcZqlcSnSncRNzHzZljNqq
CmWFbCmFvMtLLQCTbbbLtRqdSZHcdnqqNqNTRlnqNH
MpthtSMvFbvWPVDrsDgpPggD
VVRntNwmlvhGccPNfS
QZcgZppdrZQTzrBgCbrbdQrBvjLssPjSssMsfSLhTPPGvLTP
ZZcpJZHpgCgpppdrJRtVJFqVFVDRWJmtVq
dpdhtpjHtnpFRHdjRnwspMQmqpqqmVqmTVJQMmff
gSCcBCBCcgwDBLSvcLQQVTMmfmMJDqfTrrVV
gSwPzLBbNCbFnHHjhthh
dLNrRmqLqRgCNNrCJrSqqSQgjDWnGpGjDjspnlslGHnnjsQj
vVTzZFVttVBMFbFfffVVmVtHWpDspjHWWWbGjjjDsjWllW
hwFFwztTzvZmBzVfqhSSNPRPPCRPRJCr
BjfcmzCCTtNBNjcTDWwzPzDMMQPDPMws
lGpJFHnlSlnZbGnQQSBLwSPPLMsDQh
JFHHpbnZbGbZgvTmqfNgqCcvjB
ShhpqjhhVZmHhSJSSnLzdNRNTjLwNTNTzv
QffRWRrMGwLfgNcNgc
GQrQDPRBlGlsGrWtrtPDPbWpqhZqSqJJpHZSVhVhhmmBZF
ZlVVDTtTrzFDrFfB
NNGbJNNNNmpWBNbNWmjMfdjmFfPdqFMrMj
NQvRNvSRHSQBgRGQJJQQHTtcVLlVcTwVTllnRsttZs
fjsDhJsVDcVJVljFDqLqFlnnCFbzbCCCZCzCtCZrnCCM
HwQNrHWNPGPHMZCvMCbzzvHZ
dBWwWPPGrGwBlcjDlcjcjldL
NCLMHJZqCHHHMFlNBZtTZRvtStZdcRbc
wDrnpbswVgsrsWmGpDpfpBQtRSTmdvBjTjtBScctRm
gwzgbGDgpgFJMzlzPJCC
SpnfPVqFnGfPGggqfGbjZZrtWrlRlbHpZjRZ
mmJmdJBsBJsDwhJBQhTZtzdRltrrRlrtHjjl
NBscQhmsmmQLLwLmhhwmcSSGfnfSFCSMCPfHCMqG
hvVnPwZwVzQrhrVhPPPrpQVDBgMMlSTLZsgdDTSTdsssLd
RvFCqCGfbFCRbRmSBMMsLBgdFDSgdL
cRGjRWbWjvtPvrQcnr
LzLNzhpcRRcTmNDzRhTPDjMvMnVlMgjngSMrMzrQQr
tfbWfWcWddFcGFwfswFFFCrjjvlVbrQjSglSQMjgvlgl
FHWGCHCCGcwfswqHdHqwwmPqRJDpZZNRJPRPPTTJNR
gLHLLhTjZVMwMRSZZS
GdqdtlPvnQPPnsRw
tNNGvdtbdmJmHRTRJrFr
QjjdjGDvdjwpZsssvsPZFZll
mTWWMWzbPHmZwHHw
JwTbtBztMVLDSpjVtc
SZSBWtBSwnTDFSDD
CsrJWmmPrPQmpzsPmssssvnTFhvTnPhnFDFfDFnwqF
CCCCzprgrJJCgmVcpJmWLQZddHlGbMbdZMbtZNNcHHBt
fgqqrZLqZqFzFFWzZzgPPbnMNNNvQnpQnQbNbpcHNP
SdwdmwCClCCwldhRSmsvpbncjQbNNQMtjQnMvS
mDlwhMRlCwDCTVwVJRdGgfzLLzzGzGFWqGqfGD
CnVvCqvnRqHVqnWcMFnLmLnMMm
ZrdzbzbrdwtQdSfdcmmFMBWFNFWLwNNp
QFrQtJDdSZdDVHlVCPssJRll
qMpGGmVNHMGVjRJJGfRgQtjQ
flsTZCwDwWcZZPCrPZZWgLLjdJJQSJTQFSgQJJRt
ZcChshwZCDvlCZCsPHMHzqNzBmMfmBBMfh
wCtZtzCnPldZSdZp
VMspbMHspbshbPBLFsdcsLBdLs
pRrQHpNbQbrqRqJfnwfwzR
DPPcDlPwNdNRJsccpgvwBBvqGGQtqrCjwr
fMSVrMWmLZqHQgLggCHH
mZZWVTbTWWfnMWrbmznfZfsPNcdsdpRcNJplbJNcNRNl
ztlNSLhplhBHwwBBMBtv
DnVVfcGbVnGRZGgvPMpHBpCmJMDP
GnZdZZnbdpVcQjQQFjjqrlNWlrsNrFNLLsWqSF
bJQgDRfjDbJbRMTgSSPzPHCNhzQHHszz
wmnwFmDcwFGvpvwGnSWPNPWzPHhhcWSCNz
GpDtmvrdGvvBmZrLTjZRTqTjblbMfL
gBhZmtHhhhwTJqwDFqGGqPWqDb
rRLRVTrjCrCVdFjMbvGPPGDPvW
LSsVdrRNRCCffCSllQNBTNgNlmhHBJ
lCzCCDMDlzzlZtttWDnDCZPbVGLhSmSLGbSgGPgVZm
sBcNsqTQwRQRrBgbgSbPTLVSnLmV
wcqrjQsBBjdCzjdnCv
ZgHVtMQVVgvQjjtzdzfdFHppfmzwpz
CsBrBLLJSrsRCvnGvfRdvF
DbBJTJDLrJDqqqrrhJsJqVWthWlZZlZjMPZltvtMjZ
bsHlrwlnwwQJsqmJnqsPSLzTLpPGPSgPPPWmLT
fdvBtpMDfpCCfBcCcCBtDfFSgTMTGSTRPLgPWGzGgVgLVz
NDcjcDZjBCdvvjdvhlbJnprjnnbhwrqn
zRpLMMqjgMggqLDqDRVGNGdhGtvGGnvGnrznGB
VScbcZPJZWZlZbbHSJQJGtrGvtmdBBGmdGBrdn
cbPsZcPCcWfCZPcPQslljpDqwfqVgRLMTRjwVqLM
QtRWhjtsbttQtnbbQvsrRBfDNdMGBLZLVVNVGNLGWd
JwllwllJmCwzPFSJzwwTBZLDLdBBBPLZZBVTTL
ZwFSSmpwzScFSmggHQjbQvjvscQbrtnjbs
WMLWnSHSMnHjPVMVMVVJGM
zQzRcmttdftrtrdZZRzDtPZppphsVbjGbQbJTTsCbsjppG
dmrDtqfzrmZtqDvdfmZmtdqzLNlgnwgWLNvwFWgWWPNFSFNN
hvSrMwqljjBHvqhHsHshqnrZcCCpfCZZCCZZCcCfCZ
QDVTRFWlmDnpLnnPTPCZ
DVQVtmQRWRRGFVRWVvlwdShBvvSqvtjMdd
pnMQbbnDQMNMDQsnTplNTDvqPGHZGcvqmCqvmqZqmlqP
dwJdBBwdJJwLJBLSRJczWmHPzqWzzHGmvPRHGG
LrdFgSSLBsDMFFcbQb
NSnwvSPPVNnPTLVpRvVvRnqhhQQzHhLbzlqcqHzmHHqh
DFMMfBffgZJtFsJgwdDHGHHzzmqhhHQzDQGhcH
dMrZMMgFfFtZJZfBWMfVPNwPpNwPVSNVjjVWpN
dNlLSvLSdNlhphlhlWfVFFbZHqjjHHvqFZQHCQ
BcrTcJfRMRmrcbqcQgcHVCVF
fBzTJJRmfPPmnppdNwhllwlz
GqfSSmPSFwSCmFBwfQfQBfGnggLrhTrJBDDnrddsJDdLTL
cHHvVtptbzbrTQJTggnTQv
QRVbbQWbpZbVQVGfRmwfFwmjflPP
zzBQJmzQPPlddpJWlzzfdpfjvLvgmvFggMFGDVvLGHVFvvtM
CCSTrCncrhcCcwhRnCqCttFDvMFvtWtVHvFhvLVv
wCTNCSRnbnpWzlBpJspN
PTzTPlrrfrbzmftTTrrjPMsNNFZQgQHVgMtNVFMgFF
DpGBcpvdZhccdGJhqDBphZhdVRQVQQVsqFwMRwFgFNHMHwQQ
SGcLGpdGnBhDJppSDZlPTTmLrmbTLTmrZL
PzmhTqSzdDGcDhzdJDPBmJnrdVppNVVtgttMVrNnMMnV
blbQbWLvlWffCjlGCWwsnLpnpMggnpspnsrg
fQRbCZRfFZvZRQHRvHjmGmTFPcBmDhBGTzmGqS
JJVJfgJfVDdfDDcpTBgdwQMQZQRZQZwmlmWwQGcm
ttzzjjzSqPzqtqzFrPvzwNwMlMRNnnwnllSmmmQG
FCvvChhsRVhhJBdB
rbQZdRzBFTBzZZcclntHnlfJlrNgngfS
PPqGjpPGqpmDmDwqPDVnlNpnJfnnnglJCHlNfC
MMhhjMwwPvZNZTvLTZdL
ZZGgVgwfQNVNLfZsPqRsVTDspTpsqs
jdjdSbmMdMBSvMgBcWpsRpTWDHWTvRPs
httmBMhbBBjCdzShfGzJlnQLlgGGZwww
gLSLMCbVSGRPdTwtjtVfdt
TpzJpFFqmzpscslBtddjlwjjDhhldhvP
WpsTmJpHssqnHMGLnGSgbH
RRBCpJJplCchWJJHCHCvjdpMzFzrNvVgFrrMzz
btLLPGSQctnZnPwwSjgZjjjNNrvMvVrrjV
tmLPGmnbnsLLwqQPSwqGbwDfHlHWBWlCsffshDCBfWcJ
GhDFZFGZzzbCdZbZVlfv
bPNWSbSJSWSJPBBLLqClCltlwlNmllwvCQfC
PgPLqgqpWcWJJcnqJccccGrjbHhDRGMDGTDbpRhbFF
VJRffrVJvDzcRcFFbpSlQLHlvtlstbbt
NmNqPhPqPZhsQLQwSRpH
dWRnRdBmMBWgjCgVGjFcCDzf
nhhQFDmVmDGhmFpgCgBpcpHqncCt
fLLZbljhjjscCggBCLCL
PhMRhNWddWNjfRdPRfWNfVmvQFVQzVMJJDJGrmQGrQ
PNQtsHvZtsQgQLPsPtHZbfzRffRzMMqRqpzbfqng
jDwCmhrDlhBhBldrzJMmfFFbSfFnqpFb
jdljDrDrTBBnGVNcGcQLQLQPQL
MjzrjZvWQRHtjQdS
JFJlDJbcbvtRQmQbQQdf
JqNDBVNpqCBqDBCBVDcNVBqNMWgGZTPZgCrPzzvghPwrwZgG
gzggttLNDFztFCNWzrLttmFddSjsdJsgZVSsJjwjgbgZVG
pPPcqpnqHMpcRbhhMMpThvnwZSjZvdwZvwdZSBvGZSGVZZ
ThcPlHbbPHRnlRTHnMhpfltrNLWzCWWCztzffQLLDmDN
SlNJRpCGTmdFFDcbqJZFFJ
wwnWPHgsLPlVVfssLcZcjjzrDqcFzcgchZ
WVvQHQPfLwSGSvCRlNSd
wWnWcpWDcwHcRdJQTdmNsT
hprqBSvZNjFdFjsq
fSfpvhLBfltMCLzWzC
fdPfPwPmdmLZfNWjWszQNjjN
MBRSBBRBChMRQWhlmVWNsmzm
FvRcSrcRrtvrRrvrrrmcwGwLnTHHqGtwZwHdGPHP
tFPlJcDJdvLZvFlcvlHtQRthbgQjrhsgQgNr
qCnpGMnTTVwCCMnqwWfpChQHRbrgQjsQmmfrrHgHrH
GMnTSBnVTnBGbLlDDvFBLDbF
rJhPGdLSWnnrdqLhPPWGjcZZffjcgNdgNgRcNfwf
mHsDTQlsQBvWspTHzpmCTpcZgwZjZfZNRFwRjRRNMHjZ
vCzDDQsDDvbllWTllCDCCTSLbqSPVqSnJLGSqrPLtVnP
sSRdHHHSRhjShVHWVFJdQPNFpGCrQCCfflqlPvfN
gLztmctMwnBtTzMppBCCrGfQlQQqBN
bbbncfzLmmmnnZLgHZWjhsjVJjHRVSdR
bRgwCHfgfCCttRbdRLHzzGDnDnLBhmBGzvmFZD
rssprQlqlTQGNPcJGVsTBDmWzBnPnhWBvZZDBvDm
MQQTJTNGNcqrNwMwwHRdRbdgbj
sBnnsDLDBCsLTngnZLcdmppCdmpRJwJJQdMRMP
NlrTblbNNbwRPpjjbPdJ
GlztrhvfGqltqzWrcZgFZVSWWSTSncnL
FLJqLFRjzFqzJddlLfNNCjPrGSHCPHNVNVSH
TWTpngssgcPgNGPc
pGMDZpnZBMDsTTTnTsQWWZTRlbvdfZlLflZzJfdqvdRbqf
ClsJpCgsppMbFFFbHp
PvQRPqQPvRdwLNZLZqqwGPPPNTbjMcFcfHjHcMNfBNHrcDDM
GLRnzqzdRqwdZnLLPqqZdQGsVtsnlWCVVWsgtWSSVVhFWt
LNLSJjQDLlzRGwTTzQfT
WbZqchqMZqZWbmdZbhTrvPmGvwfHRHGTHRwH
dcfChsWWZgbfWdhCbgDNFBBDjFNBjjVNpD
HjCLsHJHCjnNVHdCnHtJdtQQgQDhFGFDLcwFDBFMMDBT
vWrSWSbSrRqmzlWlQgRQQTcRMgMTMFwT
bzrpWWzbqrpnZsJwZVpC
FhlfrNdTrtFdtrrrfcZBMdpZcHHHZMcccv
PmbjVDjwQbbjjVpDDvpzBZSSMsvG
jmbVjPVWqVmgJgjmmPPQjmqlCMlftnftnNlTTLLfNfrJtN
PwMWzqwWbFwznqNQQhffQjJfnhfJ
mmdpgmttDrpgpdmZdHmgNsQVZvJNMQvVJffsZVQf
pdcBrMgDgcgrrHPcFSFzzqzFFbPS
QRJJtSfJtQtjQRnSnNssTNdgsgdwddRWcm
qHMDhPBqbqZVzbddTcVwSmNWNVcc
BFCZbqPbHBPMhCljvQSvGCCpnj
HSzHNHlNHmBSHSBFrFFgBHVVqbQLTTcLtqDsDTBTDcDp
CWQZGCWfMZGqbTbtpLsbWp
GwjhPCRZPQPPCPwmzSNzzzmwzlzSgH
GgTvJbpJGvPVHZZZLW
cwWdnwmWnfwZDBHHNzZBVf
nhjjmshdwmSjsnmwrrQrtbtbgTTgrWth
lFBTtcnlcFlppVpttcFZVhTTDDLCHDSDCjDCMSLZDWdDDSjD
mrfsgMfRRwwPffJfbdDdgWGLGLSDjSSWdC
MmfNPwPzMzlhlFlplV
pRVgVsRzdDVJJJRttZTnnLrGsrGssG
BjMvMBWmjWNWSWrLGZPTHLSLTrZr
LLMWQjfvmljLBRVJfbChfVgJRz
RPDsdnVrVnVzScStjpFSjV
BTLBhMMBpSMsMjZz
hwbBgTsbBbGrGHvGrvDnPH
nzwgtSFRqhDphDwB
CmWCrrmrVPGCDTbpvvvhsZDG
VdNrlWHpmQzSMgJFdRFz
jrhZtczchvvFCTmCDlDMrMDT
bHbLnbbwLnWQpLQgQVpQCTDqdmwqmDqCdDCSlmdd
sgVgglblptsfFthtvR
LctzWvrzTWsvWBfvBzdJQSdQhQQfpDJJmmDD
lMRwjlwlLnZwLHLggQDRGphdFDJQdSdJJQ
CjPZCVCjgPwgWqWLqzzcWsVq
JNWHsPNsJNHBnfnnqfqswcctDTmPCRmmTRtgCdmD
rjGrLrbhGRZVGQhphbbmDgDZMDMwdwDcCMgcDM
zvbLvVpFvjzVhbQjGjHlnflJFlWRqBWWBJBS
NfCMfGNdGqVDhWBvncLllhBgcmgL
bJbRbHHtRtJtZTpSRtsLDLzvcvBmgnnnJlsm
SbbbTRpbQHSbbwHZZTHqfCNMfqFWGNGVQMFGDC
MdzwdMpVwVNMHQMJNcHM
mDtcPDqWnDqgnGJvLHTJHJ
mmjhhRBRBcdZrcdRCz
lvldsNpNGCGgCvCGggDLMbMmrdwnjjZdLLwrjM
HWHtPHSHPBnrmZjBbwwC
tHqWRtfttNlDClvNqs
BTRNQTQTTBFRTglDwzztDgCwLF
jZsMjqgdrrzzSbsDSwsw
jWZrMgMjGdvrWWvrWMfMfZTBHTHQBHBQNpQRfRHNpnRT
GRgFCPhnBBhPwZPnwdbWMJMlcJTLLlTlRT
VQsvVvvVNzqsscTVSLbWTStTJW
spfDNpvsnPCfhBbh
GhWSgWphprhQqqndQd
MvZRjjLcCzwcLnHfdTdgfFHQ
wCczcCgRMwRRNCtjMCtCvlBmVDGslmPpmWWNVGSpWV
PZqgTbTZvFgZbZnFvPlBsVqsGBlGVzGsqVls
MMhSmHHfrfrSrjMNfcjrSRBlBVzGVpVGgGVCGslGNd
rMhQQmDSQMjMtZvPTTnJvtQg
TNGWlqVpmPssnNssWLtRfCLbjCCwPgLjfg
ZSHvHczFBBcHhJHFvhHcSFgrCgLbfgfbwrLTtbjwLwJr
BMzSQzcQznlNQTQsnl
FVWDZDZHpDdtZlqZqZqljfNmsNFPjbbPbPRbFFjm
MJSGMghngrccvSrSzMrsQbbRmjmQmjtNtbfB
CMnvczGChCCwcgtpDDlLLLwVHdlHTZ
fTTzbQzhDwwbCnZnpbgnHncM
mGtBRBFmsRpVGMzpnnGL
lFNqtdsssrRFBltSFRFlSrvfDSWWvwfhhPJPjWfQzPvf
GWWWQlpSZzrQnjQdRHVjdjTRvddddB
ztthMtCmffcChJhChfCJdLddLBBgvqdvBBVBcgdq
smbsmbmChCJmJffPmhNthDtZwnFQZQGpSrGWGQGZpQZzWP
ZDzsjjFLFqsQzFsZqDzBHGtBHpmgdNGmGBtLBG
hbbMMTcWhbwnJPlwWrnPbbVGVNndgpVVHmdNHVBmmmtf
bCTPTclcgRZQZCgs";
    }
}
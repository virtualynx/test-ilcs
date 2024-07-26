namespace test2.Dtos;

public class GoodsInfo
{
    public string code;
    public string message;
    public GoodsInfoData[] data;
}

public class GoodsInfoData
{
    public string hs_code_format;
    public string uraian_id;
    public string sub_header;
}
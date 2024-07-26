using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using test2.Dtos;
using test2.Models;
using TodoApi.Models;

namespace test2.Controllers;

[ApiController]
[Route("[controller]")]
public class ExternalController : ControllerBase
{
    private readonly ILogger<ExternalController> _logger;

    private HttpClient httpClient;

    private _DbContext context;

    public ExternalController(ILogger<ExternalController> logger, _DbContext context)
    {
        _logger = logger;
        this.context = context;

        this.httpClient = new HttpClient();
        this.httpClient.BaseAddress = new Uri("https://api-hub.ilcs.co.id/my/n/");
        this.httpClient.DefaultRequestHeaders.Accept.Clear();
        this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [HttpGet("GoodsInfo/{code}")]
    public async Task<IActionResult> GoodsInfo(String code)
    {
        HttpResponseMessage resp = await this.httpClient.GetAsync("barang?hs_code="+code);

        // GoodsInfo gi = null;
        // if (resp.IsSuccessStatusCode)
        // {
        //     gi = await resp.Content.ReadAsAsync<GoodsInfo>();
        // }

        // return Ok(gi);

        ApiRespone gi = null;
        if (resp.IsSuccessStatusCode)
        {
            gi = await resp.Content.ReadAsAsync<ApiRespone>();
        }

        return Ok(gi);
    }

    [HttpGet("GoodsCost/{code}")]
    public async Task<IActionResult> GoodsCost(String code)
    {
        HttpResponseMessage resp = await this.httpClient.GetAsync("tarif?hs_code="+code);

        ApiRespone apiResp = null;
        if (resp.IsSuccessStatusCode)
        {
            apiResp = await resp.Content.ReadAsAsync<ApiRespone>();
        }

        return Ok(apiResp);
    }

    [HttpGet("GetCountries/{query}")]
    public async Task<IActionResult> GetCountries(String query)
    {
        HttpResponseMessage resp = await this.httpClient.GetAsync("negara?ur_negara="+query);

        ApiRespone apiResp = null;
        if (resp.IsSuccessStatusCode)
        {
            apiResp = await resp.Content.ReadAsAsync<ApiRespone>();
        }

        return Ok(apiResp);
    }

    [HttpGet("GetPorts")]
    public async Task<IActionResult> GetPorts([FromQuery]string kd_negara, string ur_pelabuhan)
    {
        HttpResponseMessage resp = await this.httpClient.GetAsync("pelabuhan?kd_negara="+kd_negara+"&ur_pelabuhan="+ur_pelabuhan);

        ApiRespone apiResp = null;
        if (resp.IsSuccessStatusCode)
        {
            apiResp = await resp.Content.ReadAsAsync<ApiRespone>();
        }
        else if(resp.StatusCode == HttpStatusCode.NotFound){
            apiResp = new ApiRespone{
                code = "404",
                message = "Not Found"
            };
        }
        else{

        }

        return Ok(apiResp);
    }

    [HttpPost]
    [Route("SaveData")]
    public async Task<IActionResult> SaveData([FromBody]SaveDataDto data)
    {
        Simulation newData = new Simulation();

        newData.kode_barang = data.kode_barang;
        newData.uraian_barang = data.uraian_barang;
        newData.bm = data.bm;
        newData.nilai_komoditas = data.nilai_komoditas;
        newData.nilai_bm = data.nilai_bm;
        newData.waktu_insert = DateTime.Now;

        context.Simulations.Add(newData);

        context.SaveChanges();

        return Ok();
    }
}

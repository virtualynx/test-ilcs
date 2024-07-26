using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Models;

public class Simulation
{
    // public string id_simulasi { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id_simulasi { get; set; }
    public string kode_barang { get; set; } //8
    public string uraian_barang { get; set; } //200
    public int bm { get; set; }
    public decimal nilai_komoditas { get; set; }
    public decimal nilai_bm { get; set; }
    public DateTime waktu_insert { get; set; }
}
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace tpmodul10_1302223154.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : Controller
    {
        public class Mahasiswa
        {
            public string nama { get; set; }
            public string nim { get; set; }
        }

        private static Mahasiswa[] mahasiswa = new Mahasiswa[]
        {
                new Mahasiswa{nama = "Darryl Rambi",nim ="1302223154" },
                new Mahasiswa{nama = "Dafa Raimi",nim ="1302223156" },
                new Mahasiswa{nama = "Haikal Risnandar",nim ="1302221050" },
                new Mahasiswa{nama = "Fersya Zufar",nim ="1302223090" },
                new Mahasiswa{nama = "Mahesa Athaya",nim ="1302220105" },
                new Mahasiswa{nama = "Raphael Permana",nim ="1302220140" },
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> GetMahasiswa()
        {
            return mahasiswa;
        }

        [HttpGet("id")]
        public Mahasiswa Get(int id)
        {
            return mahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa input)
        {
            Mahasiswa newMahasiswa = new Mahasiswa
            {
                nama = input.nama,
                nim = input.nim
            };
            Mahasiswa[] newMahasiswas = new Mahasiswa[mahasiswa.Length + 1];

            for (int i = 0; i < mahasiswa.Length; i++)
            {
                newMahasiswas[i] = mahasiswa[i];
            }
            newMahasiswas[mahasiswa.Length] = newMahasiswa;
            mahasiswa = newMahasiswas;

            return CreatedAtAction(nameof(GetMahasiswa), newMahasiswa);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= mahasiswa.Length)
            {
                return NotFound("Invalid");
            }

            for (int i = id; i < mahasiswa.Length - 1; i++)
            {
                mahasiswa[i] = mahasiswa[i + 1];
            }
            Array.Resize(ref mahasiswa, mahasiswa.Length - 1);
            
            return NoContent();
        }
    }
}

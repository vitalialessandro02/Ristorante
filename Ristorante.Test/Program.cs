using Ristorante.Test.Examples;
using Ristorante.Models.Repository;
using Ristorante.Models.Context;

MyDbContext myDbContext = new MyDbContext(); 

var esempio = new DettaglioOrdineRepository(myDbContext);
var esempioPortata = new PortataRepository(myDbContext);
var PortataByPrezzo = new PortataRepository(myDbContext);
var PortataByOrdine = new OrdineRepository(myDbContext);

int ou = 3;
var pippo = esempio.GetDettagliOrdine(0,1,out ou,1,2);
var pluto = esempioPortata.GetPortate(0, 1, out ou,null);
var minnie = PortataByPrezzo.GetPortateByPrezzo(0, 1, out ou, 62, 50, 1);
var topolino = PortataByOrdine.GetPortateByIdOrdine(0, 1, out ou, 2);
var gabibbo = PortataByOrdine.GetOrdine(0, 2, out ou, new DateTime(2023, 01, 01), new DateTime(2024, 01, 01), null);

var example = new EntityFrameworkExample();
example.RunExample();
Console.ReadLine();

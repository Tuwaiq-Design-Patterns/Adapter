using static System.Console;
namespace adapter_dp
{
    public class Adapter : IAdapter
    {
        private string _chemical;
        private readonly Service _service;
        public Adapter(string chemical)
        {
            _chemical = chemical;
            _service = new Service();
        }
        public override void Print()
        {
            Boiling = _service.GetCPoint(_chemical, "B");
            Melting = _service.GetCPoint(_chemical, "M");
            Weight = _service.GetWeight(_chemical);
            Formula = _service.GetStructure(_chemical);
            WriteLine("\n ------ Compound:  -> " + _chemical + " ------ ");
            WriteLine(" Formula -> " + Formula);
            WriteLine(" Weight -> " + Weight);
            WriteLine(" Melting Pt -> " + Melting);
            WriteLine(" Boiling Pt -> " + Boiling);
        }
    }
}
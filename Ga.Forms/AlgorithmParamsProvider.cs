using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ga.Forms
{
    public class AlgorithmParamsProvider
    {
        private BinaryFormatter bf = new BinaryFormatter();
        private string fileName = "params.bin";

        public TwoParamsAlgorithmParams Params { get; set; }

        public AlgorithmParamsProvider()
        {
            Params = new TwoParamsAlgorithmParams();
        }

        public void Save()
        {
            using (var fs = File.Open(fileName, FileMode.Create))
            {
                bf.Serialize(fs, Params);
            }
        }

        public bool TryRestore()
        {
            if (File.Exists(fileName) == false)
            {
                return false;
            }

            Stream fs = null;
            try
            {
                fs = File.OpenRead(fileName);
                Params = (TwoParamsAlgorithmParams)bf.Deserialize(fs);
            }
            catch (SystemException exc)
            {
                var message = string.Format("{0}{1}{2}", exc.Message, Environment.NewLine, "Do you want to delete the file?");
                var result = MessageBox.Show(message, "Restore params error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    fs.Close();
                    File.Delete(fileName);
                }
                return false;
            }
            finally
            {
                fs.Close();
            }

            return true;
        }
    }
}

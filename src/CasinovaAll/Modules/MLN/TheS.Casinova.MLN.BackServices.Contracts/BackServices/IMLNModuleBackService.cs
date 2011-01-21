using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Commands;

namespace TheS.Casinova.MLN.BackServices
{
    public interface IMLNModuleBackService :
                ICreateMLNInfo
    { }

    /// <summary>
    /// ส่งค่า command เพื่อสร้างระบบเครือข่าย
    /// </summary>
    public interface ICreateMLNInfo
    {
        void CreateMLNInfo(CreateMLNInfoCommand cmd);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MLN.Commands;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.MLN.DAL;
using TheS.Casinova.MLN.Models;

namespace TheS.Casinova.MLN.WebExecutors
{
    public class ListDownLineByLevelExecutor
         : SynchronousCommandExecutorBase<ListDownLineByLevelCommand>
    {
        private IListDownLineByLevel _iListDownLineByLevel;
        private IDependencyContainer _container;
        private IEnumerable<MLNInformation> _MLNInfo;

        public ListDownLineByLevelExecutor(IMLNModuleDataQuery dqr, IDependencyContainer container) 
        {
            _iListDownLineByLevel = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListDownLineByLevelCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.DownLineInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //ดึงข้อมูล DownLine level1
            _MLNInfo = _iListDownLineByLevel.List(command);
            command.MLNInfoLevel1 = CalGroupCountLevel1(_MLNInfo);

            //ดึงข้อมูล DownLine level2
            _MLNInfo = _iListDownLineByLevel.List(command);
            command.MLNInfoLevel2 = CalGroupCountLevel2(_MLNInfo);

            //ดึงข้อมูล DownLine level3
            command.MLNInfoLevel3 = _iListDownLineByLevel.List(command);
        }

        public IEnumerable<MLNInformation> CalGroupCountLevel1(IEnumerable<MLNInformation> MLNInfo) 
        {
            List<MLNInformation> list = new List<MLNInformation>();

            //คำนวนจำนวน downline ที่มีผลต่อตัวเอง
            foreach (var item in MLNInfo) 
            {
                item.GroupCount = item.TotalDownLineLevel1 + item.TotalDownLineLevel2;
                list.Add(item);
            }

            return list;
        }

        public IEnumerable<MLNInformation> CalGroupCountLevel2(IEnumerable<MLNInformation> MLNInfo)
        {
            List<MLNInformation> list = new List<MLNInformation>();

            //คำนวนจำนวน downline ที่มีผลต่อตัวเอง
            foreach (var item in MLNInfo) {
                item.GroupCount = item.TotalDownLineLevel1;
                list.Add(item);
            }

            return list;
        }
    }
}

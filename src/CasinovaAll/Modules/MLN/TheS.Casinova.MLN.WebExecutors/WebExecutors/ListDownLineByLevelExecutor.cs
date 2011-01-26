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
using TheS.Casinova.MLN.Command;

namespace TheS.Casinova.MLN.WebExecutors
{
    public class ListDownLineByLevelExecutor
         : SynchronousCommandExecutorBase<ListDownLineByLevelCommand>
    {
        private IListDownLineByLevel1 _iListDownLineByLevel1;
        private IListDownLineByLevel2 _iListDownLineByLevel2;
        private IListDownLineByLevel3 _iListDownLineByLevel3;
        private IDependencyContainer _container;
        private IEnumerable<MLNInformation> _MLNInfo;

        public ListDownLineByLevelExecutor(IMLNModuleDataQuery dqr, IDependencyContainer container) 
        {
            _iListDownLineByLevel1 = dqr;
            _iListDownLineByLevel2 = dqr;
            _iListDownLineByLevel3 = dqr;
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
            ListDownLineByLevel1Command cmd1;
            cmd1 = new ListDownLineByLevel1Command {
                DownLineInfo = new MLNInformation { 
                    UplineLevel1= command.DownLineInfo.UserName
                }
            };

            _MLNInfo = _iListDownLineByLevel1.List(cmd1);
            cmd1.MLNInfoLevel1 = CalGroupCountLevel1(_MLNInfo);

            //ดึงข้อมูล DownLine level2
            ListDownLineByLevel2Command cmd2;
            cmd2 = new ListDownLineByLevel2Command {
                DownLineInfo = new MLNInformation {
                    UplineLevel2 = command.DownLineInfo.UserName
                }
            };
            
            _MLNInfo = _iListDownLineByLevel2.List(cmd2);
            cmd2.MLNInfoLevel2 = CalGroupCountLevel2(_MLNInfo);

            //ดึงข้อมูล DownLine level3
            ListDownLineByLevel3Command cmd3;
            cmd3 = new ListDownLineByLevel3Command {
                DownLineInfo = new MLNInformation {
                    UplineLevel3 = command.DownLineInfo.UserName
                }
            };
            _MLNInfo = _iListDownLineByLevel3.List(cmd3);
            cmd3.MLNInfoLevel3 = CalGroupCountLevel3(_MLNInfo);
        }

        public IEnumerable<MLNInformation> CalGroupCountLevel1(IEnumerable<MLNInformation> MLNInfo) 
        {
            List<MLNInformation> list = new List<MLNInformation>();

            //คำนวนจำนวน downline level1 ที่มีผลต่อตัวเอง
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

            //คำนวนจำนวน downline level2 ที่มีผลต่อตัวเอง
            foreach (var item in MLNInfo) {
                item.GroupCount = item.TotalDownLineLevel1;
                list.Add(item);
            }

            return list;
        }

        public IEnumerable<MLNInformation> CalGroupCountLevel3(IEnumerable<MLNInformation> MLNInfo)
        {
            List<MLNInformation> list = new List<MLNInformation>();

            //คำนวนจำนวน downline level3 ที่มีผลต่อตัวเอง
            foreach (var item in MLNInfo) {
                item.GroupCount = 0;
                list.Add(item);
            }

            return list;
        }
    }
}

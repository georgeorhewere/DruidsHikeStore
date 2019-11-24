using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.ViewModels.ServiceResult
{
    public abstract class BaseServiceResultViewModel
    {
        public abstract bool success { set; get; }
        public abstract dynamic data { set; get; }
        public abstract string message { set; get; }
    }

    public class ServiceResultViewModel : BaseServiceResultViewModel
    {
        private bool _success;
        private dynamic _data;
        private string _message;

        public ServiceResultViewModel(bool status, dynamic data)
        {
            success = status;
            this.data = data;           

        }

        public override bool success { get => _success; set => _success = value; }
        public override dynamic data { get => _data; set => _data = value; }
        public override string message { get => _message; set => message = value; }
    }
}

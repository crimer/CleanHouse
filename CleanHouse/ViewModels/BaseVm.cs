using System;
using CleanHouse.Application.Helpers;

namespace CleanHouse.ViewModels
{
    public abstract class BaseVm : Bindable, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
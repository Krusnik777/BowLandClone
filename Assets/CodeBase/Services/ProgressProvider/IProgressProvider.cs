﻿using CodeBase.Data;
using CodeBase.Infrastructure.DependencyInjection;

namespace CodeBase.Services.ProgressProvider
{
    public interface IProgressProvider : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}
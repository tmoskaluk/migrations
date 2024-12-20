﻿using System;

namespace Cars.SharedKernel;

public interface IAppLogger
{
    void Trace(string message);

    void Debug(string message);

    void Info(string message);

    void Warn(string message);

    void Warn(Exception exception);

    void Error(string message);

    void Error(Exception exception);

    void Fatal(string message);

    void Fatal(Exception exception);
}
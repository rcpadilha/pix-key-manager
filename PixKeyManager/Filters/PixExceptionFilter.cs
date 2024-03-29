﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PixKeyManager.Domain.Model.Base;
using PixKeyManager.Exceptions;

namespace PixKeyManager.Filters;

public class PixExceptionFilter: IExceptionFilter
{
    private readonly ILogger<PixExceptionFilter> _logger;

    public PixExceptionFilter(ILogger<PixExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseHttpException httpException)
        {
            HandleHttpException(context, httpException);
        }
        else
        {
            HandleGenericException(context);
        }

    context.ExceptionHandled = true;
    }

    private void HandleHttpException(ExceptionContext context,
        BaseHttpException httpException)
    {
        context.Result = new JsonResult(
            new ErrorResultDto(httpException.Message))
        {
            StatusCode = (int)httpException.StatusCode,
        };
    }

    private void HandleGenericException(ExceptionContext context)
    {
        _logger.LogError("Exceção não tratada: {}", context.Exception.Message);
        _logger.LogError("Stack Trace: {}", context.Exception.StackTrace);

        context.Result = new JsonResult(
            new ErrorResultDto("Erro inesperado. Tente novamente mais tarde!"))
        {
            StatusCode = (int)HttpStatusCode.InternalServerError,
        };
    }
}


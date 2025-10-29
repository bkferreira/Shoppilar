using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Ext;
using Shoppilar.DTOs.Util;

namespace Shoppilar.Interfaces.Ext;

public interface ISmsService
{
    Task<BaseResponse> SendAsync(SmsInput smsInput, CancellationToken cancellationToken = default);
}
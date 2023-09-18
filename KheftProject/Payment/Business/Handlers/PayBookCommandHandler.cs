using System.Text;
using FluentValidation;
using KheftProject.Core.Contexts;
using KheftProject.Payment.Business.Contracts.Commands;
using KheftProject.Payment.Business.Contracts.Dtos;
using KheftProject.Payment.Business.Contracts.Responses;
using MediatR;
using Newtonsoft.Json;

namespace KheftProject.Payment.Business.Handlers;

public class PayBookCommandHandler : IRequestHandler<PayBookCommand, ResponseDto>
{
    private readonly IValidator<PayBookCommand> _validator;
    private readonly IConfiguration _configuration;

    public PayBookCommandHandler(IValidator<PayBookCommand> validator, IConfiguration configuration)
    {
        _validator = validator;
        _configuration = configuration;
    }

    public async Task<ResponseDto> Handle(PayBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("content-type", "application/json");
            var paymentAuthorityRequestUrl = _configuration["Payment:RequestUrl"];
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, paymentAuthorityRequestUrl);
            var callBackUrl = new StringBuilder(_configuration["Payment:Authority"]).Append(request.BookId).ToString();
            var authorityRequest = new AuthorityRequest()
            {
                Amount = request.Price,
                MerchantId = _configuration["Payment:MerchantId"]!,
                CallBackUrl = callBackUrl
            };
            var body = new StringContent(JsonConvert.SerializeObject(authorityRequest), Encoding.UTF8, "application/json");
            httpRequest.Content = body;
            var response = await httpClient.SendAsync(httpRequest, cancellationToken);
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            var authorityResponse = JsonConvert.DeserializeObject<AuthorityResponse>(responseString);
            if (authorityResponse.Data.Code != 100 || authorityResponse.Data.Message != "Success")
            {
                return new ResponseDto()
                {
                    StatusCode = 400,
                    Message = authorityResponse.Errors
                };
            }
            var authorityUrl = _configuration["Payment:Authority"];
            return new ResponseDto()
            {
                StatusCode = 200,
                Message = authorityUrl
            };
        }
        catch (Exception e)
        {
            return new ResponseDto()
            {
                Message = "error has been occured during getting Authority payment page url",
                StatusCode = 400
            };
        }
    }
}
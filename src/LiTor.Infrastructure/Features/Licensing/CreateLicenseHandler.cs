using LiTor.Core.Features.Licensing;
using MediatR;
using Standard.Licensing;

namespace LiTor.Infrastructure.Features.Licensing;
public class CreateLicenseHandler : IRequestHandler<CreateLicenseRequest, CreateLicenseResponse>
{


  public Task<CreateLicenseResponse> Handle(CreateLicenseRequest request, CancellationToken cancellationToken)
  {
    var keyGenerator = Standard.Licensing.Security.Cryptography.KeyGenerator.Create();
    var keyPair = keyGenerator.GenerateKeyPair();
    var privateKey = keyPair.ToEncryptedPrivateKeyString(request.PassPhrase);
    var publicKey = keyPair.ToPublicKeyString();

    var license = License.New()
    .WithUniqueIdentifier(Guid.NewGuid())
    .As(LicenseType.Trial)
    .ExpiresAt(DateTime.Now.AddDays(30))
    .WithMaximumUtilization(5)
    .WithProductFeatures(new Dictionary<string, string>
        {
            {"Sales Module", "yes"},
            {"Purchase Module", "yes"},
            {"Maximum Transactions", "10000"}
        })
    .LicensedTo("John Doe", "john.doe@example.com")
    .CreateAndSignWithPrivateKey(privateKey, request.PassPhrase);

    return Task.FromResult(new CreateLicenseResponse()
    {
      PassPhrase = request.PassPhrase,
      PrivateKey = privateKey,
      PublicKey = publicKey,
      LicenseContent  = license.ToString()
    });

  }

}

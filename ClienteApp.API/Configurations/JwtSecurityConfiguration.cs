using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClientesApp.API.Configurations
{
    public class JwtSecurityConfiguration
    {
        public static void AddJwtSecurity(IServiceCollection services)
        {
            var secretKey = "86F0FB01-3A5A-4020-AACF-2614EF1CEF07";

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, //Não precisa validar a origem do token
                        ValidateAudience = false,//Não precisa validar o destinatário do token
                        ValidateLifetime = true, //Verifica o tempo de expiração do token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) //Verificando se o TOKEN está assinado com a minha chave de autenticação
                    };
                });
        }
    }
}

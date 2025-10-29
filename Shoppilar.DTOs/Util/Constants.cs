namespace Shoppilar.DTOs.Util;

public abstract class Constants
{
    public const string TokenKey = "token";
    public const string RefreshTokenKey = "refresh-token";
    public const string PhoneConfirmationPurpose = "PHONE_CONFIRM";
    public const string ResetPasswordPurpose = "RESET_PASSWORD";
    public const int PhoneCodeExpiryTime = 5;
    public const int ResetCodeExpiryTime = 10;

    public const string MessagePhoneConfirmationPurpose =
        "Bem-vindo(a) à Shoppilar!\nPara ativar sua conta, use o código: {codigo}.\nEste código é válido por {tempo} minutos. Não compartilhe este código com ninguém.\n";

    public const string MessageResetPasswordPurpose =
        "Olá!\nO código para redefinir sua senha é: {codigo}.\nEle é válido por {tempo} minutos. Não compartilhe este código com ninguém.\n";
}
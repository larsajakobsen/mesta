using System.Text.Json.Serialization;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Mesta.Users.Api.Gateways.Keycloak.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Attributes
{
    public string cibaBackchannelTokenDeliveryMode { get; set; }
    public string cibaAuthRequestedUserHint { get; set; }
    public string oauth2DevicePollingInterval { get; set; }
    public string clientOfflineSessionMaxLifespan { get; set; }
    public string clientSessionIdleTimeout { get; set; }

    [JsonPropertyName("actionTokenGeneratedByUserLifespan-execute-actions")]
    public string actionTokenGeneratedByUserLifespanexecuteactions { get; set; }

    [JsonPropertyName("actionTokenGeneratedByUserLifespan-verify-email")]
    public string actionTokenGeneratedByUserLifespanverifyemail { get; set; }

    public string clientOfflineSessionIdleTimeout { get; set; }

    [JsonPropertyName("actionTokenGeneratedByUserLifespan-reset-credentials")]
    public string actionTokenGeneratedByUserLifespanresetcredentials { get; set; }

    public string cibaInterval { get; set; }
    public string realmReusableOtpCode { get; set; }
    public string cibaExpiresIn { get; set; }
    public string oauth2DeviceCodeLifespan { get; set; }

    [JsonPropertyName("actionTokenGeneratedByUserLifespan-idp-verify-account-via-email")]
    public string actionTokenGeneratedByUserLifespanidpverifyaccountviaemail { get; set; }

    public string parRequestUriLifespan { get; set; }
    public string clientSessionMaxLifespan { get; set; }
    public string shortVerificationUri { get; set; }
}

public class BrowserSecurityHeaders
{
    public string contentSecurityPolicyReportOnly { get; set; }
    public string xContentTypeOptions { get; set; }
    public string xRobotsTag { get; set; }
    public string xFrameOptions { get; set; }
    public string contentSecurityPolicy { get; set; }
    public string xXSSProtection { get; set; }
    public string strictTransportSecurity { get; set; }
}

public class ClientPolicies
{
    public List<object> policies { get; set; }
}

public class ClientProfiles
{
    public List<object> profiles { get; set; }
}

public class DefaultRole
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public bool composite { get; set; }
    public bool clientRole { get; set; }
    public string containerId { get; set; }
}

public class KeycloakRealm
{
    public string id { get; set; }
    public string realm { get; set; }
    public int notBefore { get; set; }
    public string defaultSignatureAlgorithm { get; set; }
    public bool revokeRefreshToken { get; set; }
    public int refreshTokenMaxReuse { get; set; }
    public int accessTokenLifespan { get; set; }
    public int accessTokenLifespanForImplicitFlow { get; set; }
    public int ssoSessionIdleTimeout { get; set; }
    public int ssoSessionMaxLifespan { get; set; }
    public int ssoSessionIdleTimeoutRememberMe { get; set; }
    public int ssoSessionMaxLifespanRememberMe { get; set; }
    public int offlineSessionIdleTimeout { get; set; }
    public bool offlineSessionMaxLifespanEnabled { get; set; }
    public int offlineSessionMaxLifespan { get; set; }
    public int clientSessionIdleTimeout { get; set; }
    public int clientSessionMaxLifespan { get; set; }
    public int clientOfflineSessionIdleTimeout { get; set; }
    public int clientOfflineSessionMaxLifespan { get; set; }
    public int accessCodeLifespan { get; set; }
    public int accessCodeLifespanUserAction { get; set; }
    public int accessCodeLifespanLogin { get; set; }
    public int actionTokenGeneratedByAdminLifespan { get; set; }
    public int actionTokenGeneratedByUserLifespan { get; set; }
    public int oauth2DeviceCodeLifespan { get; set; }
    public int oauth2DevicePollingInterval { get; set; }
    public bool enabled { get; set; }
    public string sslRequired { get; set; }
    public bool registrationAllowed { get; set; }
    public bool registrationEmailAsUsername { get; set; }
    public bool rememberMe { get; set; }
    public bool verifyEmail { get; set; }
    public bool loginWithEmailAllowed { get; set; }
    public bool duplicateEmailsAllowed { get; set; }
    public bool resetPasswordAllowed { get; set; }
    public bool editUsernameAllowed { get; set; }
    public bool bruteForceProtected { get; set; }
    public bool permanentLockout { get; set; }
    public int maxFailureWaitSeconds { get; set; }
    public int minimumQuickLoginWaitSeconds { get; set; }
    public int waitIncrementSeconds { get; set; }
    public int quickLoginCheckMilliSeconds { get; set; }
    public int maxDeltaTimeSeconds { get; set; }
    public int failureFactor { get; set; }
    public DefaultRole defaultRole { get; set; }
    public List<string> requiredCredentials { get; set; }
    public string passwordPolicy { get; set; }
    public string otpPolicyType { get; set; }
    public string otpPolicyAlgorithm { get; set; }
    public int otpPolicyInitialCounter { get; set; }
    public int otpPolicyDigits { get; set; }
    public int otpPolicyLookAheadWindow { get; set; }
    public int otpPolicyPeriod { get; set; }
    public bool otpPolicyCodeReusable { get; set; }
    public List<string> otpSupportedApplications { get; set; }
    public string webAuthnPolicyRpEntityName { get; set; }
    public List<string> webAuthnPolicySignatureAlgorithms { get; set; }
    public string webAuthnPolicyRpId { get; set; }
    public string webAuthnPolicyAttestationConveyancePreference { get; set; }
    public string webAuthnPolicyAuthenticatorAttachment { get; set; }
    public string webAuthnPolicyRequireResidentKey { get; set; }
    public string webAuthnPolicyUserVerificationRequirement { get; set; }
    public int webAuthnPolicyCreateTimeout { get; set; }
    public bool webAuthnPolicyAvoidSameAuthenticatorRegister { get; set; }
    public List<object> webAuthnPolicyAcceptableAaguids { get; set; }
    public string webAuthnPolicyPasswordlessRpEntityName { get; set; }
    public List<string> webAuthnPolicyPasswordlessSignatureAlgorithms { get; set; }
    public string webAuthnPolicyPasswordlessRpId { get; set; }
    public string webAuthnPolicyPasswordlessAttestationConveyancePreference { get; set; }
    public string webAuthnPolicyPasswordlessAuthenticatorAttachment { get; set; }
    public string webAuthnPolicyPasswordlessRequireResidentKey { get; set; }
    public string webAuthnPolicyPasswordlessUserVerificationRequirement { get; set; }
    public int webAuthnPolicyPasswordlessCreateTimeout { get; set; }
    public bool webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; set; }
    public List<object> webAuthnPolicyPasswordlessAcceptableAaguids { get; set; }
    public BrowserSecurityHeaders browserSecurityHeaders { get; set; }
    public SmtpServer smtpServer { get; set; }
    public bool eventsEnabled { get; set; }
    public List<string> eventsListeners { get; set; }
    public List<object> enabledEventTypes { get; set; }
    public bool adminEventsEnabled { get; set; }
    public bool adminEventsDetailsEnabled { get; set; }
    public List<object> identityProviders { get; set; }
    public List<object> identityProviderMappers { get; set; }
    public bool internationalizationEnabled { get; set; }
    public List<object> supportedLocales { get; set; }
    public string browserFlow { get; set; }
    public string registrationFlow { get; set; }
    public string directGrantFlow { get; set; }
    public string resetCredentialsFlow { get; set; }
    public string clientAuthenticationFlow { get; set; }
    public string dockerAuthenticationFlow { get; set; }
    public Attributes attributes { get; set; }
    public bool userManagedAccessAllowed { get; set; }
    public ClientProfiles clientProfiles { get; set; }
    public ClientPolicies clientPolicies { get; set; }
}

public class SmtpServer
{
    public string replyToDisplayName { get; set; }
    public string starttls { get; set; }
    public string auth { get; set; }
    public string envelopeFrom { get; set; }
    public string ssl { get; set; }
    public string password { get; set; }
    public string port { get; set; }
    public string host { get; set; }
    public string replyTo { get; set; }
    public string from { get; set; }
    public string fromDisplayName { get; set; }
    public string user { get; set; }
}
# IO.Swagger.Api.AuthenticationApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiAuthenticationPost**](AuthenticationApi.md#apiauthenticationpost) | **POST** /api/authentication | 

<a name="apiauthenticationpost"></a>
# **ApiAuthenticationPost**
> void ApiAuthenticationPost (AuthenticationRequest body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthenticationPostExample
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();
            var body = new AuthenticationRequest(); // AuthenticationRequest |  (optional) 

            try
            {
                apiInstance.ApiAuthenticationPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticationApi.ApiAuthenticationPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AuthenticationRequest**](AuthenticationRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

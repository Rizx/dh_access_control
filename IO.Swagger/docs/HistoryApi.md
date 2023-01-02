# IO.Swagger.Api.HistoryApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiHistoryGet**](HistoryApi.md#apihistoryget) | **GET** /api/history | List History
[**ApiHistoryPost**](HistoryApi.md#apihistorypost) | **POST** /api/history | Register History

<a name="apihistoryget"></a>
# **ApiHistoryGet**
> void ApiHistoryGet ()

List History

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiHistoryGetExample
    {
        public void main()
        {
            var apiInstance = new HistoryApi();

            try
            {
                // List History
                apiInstance.ApiHistoryGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling HistoryApi.ApiHistoryGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apihistorypost"></a>
# **ApiHistoryPost**
> void ApiHistoryPost (HistoryRequest body = null)

Register History

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiHistoryPostExample
    {
        public void main()
        {
            var apiInstance = new HistoryApi();
            var body = new HistoryRequest(); // HistoryRequest |  (optional) 

            try
            {
                // Register History
                apiInstance.ApiHistoryPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling HistoryApi.ApiHistoryPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**HistoryRequest**](HistoryRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# IO.Swagger.Api.MemberApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiMemberCardPost**](MemberApi.md#apimembercardpost) | **POST** /api/member/card | Register Member
[**ApiMemberGet**](MemberApi.md#apimemberget) | **GET** /api/member | List Member
[**ApiMemberIdGet**](MemberApi.md#apimemberidget) | **GET** /api/member/id | Get by id
[**ApiMemberPost**](MemberApi.md#apimemberpost) | **POST** /api/member | Register Member
[**ApiMemberPut**](MemberApi.md#apimemberput) | **PUT** /api/member | Update Member

<a name="apimembercardpost"></a>
# **ApiMemberCardPost**
> void ApiMemberCardPost (RegisterCardRequest body = null)

Register Member

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiMemberCardPostExample
    {
        public void main()
        {
            var apiInstance = new MemberApi();
            var body = new RegisterCardRequest(); // RegisterCardRequest |  (optional) 

            try
            {
                // Register Member
                apiInstance.ApiMemberCardPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MemberApi.ApiMemberCardPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**RegisterCardRequest**](RegisterCardRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apimemberget"></a>
# **ApiMemberGet**
> void ApiMemberGet ()

List Member

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiMemberGetExample
    {
        public void main()
        {
            var apiInstance = new MemberApi();

            try
            {
                // List Member
                apiInstance.ApiMemberGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MemberApi.ApiMemberGet: " + e.Message );
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
<a name="apimemberidget"></a>
# **ApiMemberIdGet**
> void ApiMemberIdGet (long? id = null)

Get by id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiMemberIdGetExample
    {
        public void main()
        {
            var apiInstance = new MemberApi();
            var id = 789;  // long? |  (optional) 

            try
            {
                // Get by id
                apiInstance.ApiMemberIdGet(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MemberApi.ApiMemberIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **long?**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apimemberpost"></a>
# **ApiMemberPost**
> void ApiMemberPost (MemberRequest body = null)

Register Member

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiMemberPostExample
    {
        public void main()
        {
            var apiInstance = new MemberApi();
            var body = new MemberRequest(); // MemberRequest |  (optional) 

            try
            {
                // Register Member
                apiInstance.ApiMemberPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MemberApi.ApiMemberPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**MemberRequest**](MemberRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apimemberput"></a>
# **ApiMemberPut**
> void ApiMemberPut (MemberRequest body = null)

Update Member

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiMemberPutExample
    {
        public void main()
        {
            var apiInstance = new MemberApi();
            var body = new MemberRequest(); // MemberRequest |  (optional) 

            try
            {
                // Update Member
                apiInstance.ApiMemberPut(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MemberApi.ApiMemberPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**MemberRequest**](MemberRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

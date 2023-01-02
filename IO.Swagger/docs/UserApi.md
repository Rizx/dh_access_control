# IO.Swagger.Api.UserApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiUserGet**](UserApi.md#apiuserget) | **GET** /api/user | List User
[**ApiUserIdGet**](UserApi.md#apiuseridget) | **GET** /api/user/id | Get by id
[**ApiUserPost**](UserApi.md#apiuserpost) | **POST** /api/user | Register User
[**ApiUserPut**](UserApi.md#apiuserput) | **PUT** /api/user | Update User
[**ApiUserRolesGet**](UserApi.md#apiuserrolesget) | **GET** /api/user/roles | List User Role

<a name="apiuserget"></a>
# **ApiUserGet**
> void ApiUserGet ()

List User

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserGetExample
    {
        public void main()
        {
            var apiInstance = new UserApi();

            try
            {
                // List User
                apiInstance.ApiUserGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserGet: " + e.Message );
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
<a name="apiuseridget"></a>
# **ApiUserIdGet**
> void ApiUserIdGet (long? id = null)

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
    public class ApiUserIdGetExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var id = 789;  // long? |  (optional) 

            try
            {
                // Get by id
                apiInstance.ApiUserIdGet(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserIdGet: " + e.Message );
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
<a name="apiuserpost"></a>
# **ApiUserPost**
> void ApiUserPost (UserRequest body = null)

Register User

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserPostExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var body = new UserRequest(); // UserRequest |  (optional) 

            try
            {
                // Register User
                apiInstance.ApiUserPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserRequest**](UserRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiuserput"></a>
# **ApiUserPut**
> void ApiUserPut (UserRequest body = null)

Update User

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserPutExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var body = new UserRequest(); // UserRequest |  (optional) 

            try
            {
                // Update User
                apiInstance.ApiUserPut(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserRequest**](UserRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiuserrolesget"></a>
# **ApiUserRolesGet**
> void ApiUserRolesGet ()

List User Role

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiUserRolesGetExample
    {
        public void main()
        {
            var apiInstance = new UserApi();

            try
            {
                // List User Role
                apiInstance.ApiUserRolesGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.ApiUserRolesGet: " + e.Message );
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

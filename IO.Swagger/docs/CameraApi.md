# IO.Swagger.Api.CameraApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiCameraGet**](CameraApi.md#apicameraget) | **GET** /api/camera | 
[**ApiCameraStreamingGet**](CameraApi.md#apicamerastreamingget) | **GET** /api/camera/streaming | 
[**ApiCameraVideosGet**](CameraApi.md#apicameravideosget) | **GET** /api/camera/videos | 

<a name="apicameraget"></a>
# **ApiCameraGet**
> void ApiCameraGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiCameraGetExample
    {
        public void main()
        {
            var apiInstance = new CameraApi();

            try
            {
                apiInstance.ApiCameraGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CameraApi.ApiCameraGet: " + e.Message );
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
<a name="apicamerastreamingget"></a>
# **ApiCameraStreamingGet**
> void ApiCameraStreamingGet (long? id = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiCameraStreamingGetExample
    {
        public void main()
        {
            var apiInstance = new CameraApi();
            var id = 789;  // long? |  (optional) 

            try
            {
                apiInstance.ApiCameraStreamingGet(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CameraApi.ApiCameraStreamingGet: " + e.Message );
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
<a name="apicameravideosget"></a>
# **ApiCameraVideosGet**
> void ApiCameraVideosGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiCameraVideosGetExample
    {
        public void main()
        {
            var apiInstance = new CameraApi();

            try
            {
                apiInstance.ApiCameraVideosGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CameraApi.ApiCameraVideosGet: " + e.Message );
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

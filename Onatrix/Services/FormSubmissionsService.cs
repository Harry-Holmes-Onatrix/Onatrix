using Onatrix.ViewModels;
using Umbraco.Cms.Core.Services;

namespace Onatrix.Services;

public class FormSubmissionsService(IContentService contentService)
{
    private readonly IContentService _contentService = contentService;

    public bool SaveCallbackRequest(CallbackFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(c => c.ContentType.Alias == "formSubmissions");

            if (container == null)
                return false;

            var requestName = $"Callback Request - {DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "callbackRequest");

            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool SaveServiceQuestion(ServiceQuestionViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(c => c.ContentType.Alias == "formSubmissions");

            if (container == null)
                return false;

            var questionName = $"Question  - {DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var question = _contentService.Create(questionName, container, "serviceQuestion");

            question.SetValue("serviceQuestionName", model.Name);
            question.SetValue("serviceQuestionEmail", model.Email);
            question.SetValue("serviceQuestionQuestion", model.Question);

            var saveResult = _contentService.Save(question);
            return saveResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool SaveOnlineSupportRequest(OnlineSupportViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(c => c.ContentType.Alias == "formSubmissions");

            if(container == null)
                return false;

            var requestName = $"Online Support Request - {DateTime.Now:yyyy-MM-dd HH:mm} - {model.Email}";
            var request = _contentService.Create(requestName, container, "onlineSupportRequest");

            request.SetValue("onlineSupportEmail", model.Email);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
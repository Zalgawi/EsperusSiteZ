@ModelType Esperus.Areas.Admin.Models.ViewMessageModel

<div class="toast" id="message-toast" role="alert" aria-live="assertive" aria-atomic="true">
  <div class="toast-header">
    <strong class="mr-auto">@Model.ResponseHeading</strong>
    <small>@Model.ResponseType</small>
    <button type="button" Class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
      <span aria-hidden="true">&times;</span>
    </button>
  </div>
  <div Class="toast-body">@Model.ResponseBody</div>
</div>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Images;


namespace SampleAPIDall.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageGeneratorController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult>Post(string prompt)
        {
            var imageClient = new ImageClient("dall-e-3", "OpenAI-Api-Key");

            var imageRequest = new ImageGenerationOptions()
            {
                Quality = GeneratedImageQuality.High,
                Size = GeneratedImageSize.W1024xH1024,
                Style = GeneratedImageStyle.Natural,
                ResponseFormat = GeneratedImageFormat.Uri,
            };

            var res = await imageClient.GenerateImageAsync(prompt, imageRequest);

            return Ok(res.Value.ImageUri);
        }


        [HttpPost]
        [Route("CustomImage")]
        public async Task<IActionResult> CustomImage(string prompt)
        {
            var imageClient = new ImageClient("dall-e-2", "OpenAI-Api-Key");


            var imageRequest = new ImageEditOptions()
            {
                Size = GeneratedImageSize.W1024xH1024,
                ResponseFormat = GeneratedImageFormat.Uri,
            };

            var res = await imageClient.GenerateImageEditAsync("Image File Path.. what we may have store or any thin",prompt,imageRequest);

            return Ok(res.Value.ImageUri);
        }

        [HttpPost]
        [Route("ImageVariation")]
        public async Task<IActionResult> ImageVariationImage(string prompt)
        {
            var imageClient = new ImageClient("dall-e-2", "OpenAI-Api-Key");


            var ImageVariation = new ImageVariationOptions()
            {
                Size = GeneratedImageSize.W1024xH1024,
                ResponseFormat = GeneratedImageFormat.Uri,
            };

            var res = await imageClient.GenerateImageVariationAsync("image PAth", ImageVariation);

            return Ok(res.Value.ImageUri);
        }

    }
}

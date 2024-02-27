
const RenderFeatures = (features, container) => {
    container.empty();

    for (const feature of features) {
        container.append(
            `<div class=" main card border-secondary mb-3" style="max-width: 18rem;">
          <div class="card-body">
            <h5 class="card-title">${feature.description}</h5> 
          </div>
        </div>`)
    }
}


const LoadFeatures = () => {
    const container = $("#features")
    const carEncodedName = container.data("encodedName");

    $.ajax({
        url: `/Car/${carEncodedName}/Feature`,
        type: 'get',
        success: function (data) {
            if (!data.length) {
                container.html("To gołoszenie nie posiada wyposażenia!")
            } else {
                RenderFeatures(data, container)
            }
        },
        error: function () {
            toastr["error"]("Coś poszło nie tak!")
        }
    })
}



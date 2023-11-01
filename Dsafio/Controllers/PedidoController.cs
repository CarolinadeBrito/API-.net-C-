using Microsoft.AspNetCore.Mvc;
using MongoExemple.Services;
using MongoDB.Models;

namespace MongoExemple.Controllers;

[Controller]
[Route("api/[controller]")]
public class PedidoController: Controller{
    private readonly MongoDBService _mongoDBService;
    
    public PedidoController(MongoDBService mongoDBService){
        _mongoDBService= mongoDBService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Pedido>>> Get(){
    var pedidos = await _mongoDBService.GetAsync();
    return Ok(pedidos);
}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pedido pedido){
        await _mongoDBService.CreateAsync(pedido);
        return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
    }

    [HttpPut ("{id}")]
    public async Task<IActionResult> AddtoPedido(string id, [FromBody] string pedidoId) {
        await _mongoDBService.AddToPedidoAsync(id, pedidoId);
        return NoContent();
    }

     [HttpDelete ("{id}")]
     public async Task<IActionResult> Delete(string id) {
         await _mongoDBService.DeleteAsync(id);
        return NoContent();
     }

}
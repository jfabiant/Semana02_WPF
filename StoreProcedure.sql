-- Use database neptuno
use neptuno;

select * from detallesdepedidos;
select * from Pedidos;
select * from productos;


create procedure Usp_Detalle_Pedido
@idpedido int
as
select pro.idproducto, pro.nombreProducto, pro.idProveedor, pro.idCategoria, pro.cantidadPorUnidad,
pro.precioUnidad, pro.unidadesEnExistencia, pro.unidadesEnPedido, pro.nivelNuevoPedido,
pro.suspendido, pro.categoriaProducto
from detallesdepedidos det inner join productos pro
on det.idproducto = pro.idproducto
inner join Pedidos ped on det.idpedido = ped.IdPedido
where det.idpedido = 10248;
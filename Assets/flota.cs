using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flota : MonoBehaviour
{
    public float cantidadDeUnidades;
    public float periodoDeDias;
    private const float kmPorDiaPorUnidad = 90f;
    private const float kmPorLitro = 15f;
    private const float costoPorLitro = 130f;
    private const float descuentoPorcentaje = 0.20f;
    private const float umbralDescuentoLitros = 100f;
    // Start is called before the first frame update
    void Start()
    {
        CalcularCostoCombustible();
    }

    void CalcularCostoCombustible()
    {
        
        if (cantidadDeUnidades < 1)
        {
            Debug.LogError("Error: La cantidad de unidades debe ser al menos 1.");
            return;
        }

        if (periodoDeDias < 5)
        {
            Debug.LogError("Error: El periodo de días debe ser al menos 5.");
            return;
        }

        
        float distanciaTotal = cantidadDeUnidades * periodoDeDias * kmPorDiaPorUnidad;
        float litrosRequeridos = distanciaTotal / kmPorLitro;
        float costoTotalCombustible = litrosRequeridos * costoPorLitro;

        
        bool aplicaDescuento = litrosRequeridos > umbralDescuentoLitros;
        float montoDescuento = aplicaDescuento ? costoTotalCombustible * descuentoPorcentaje : 0f;
        float costoFinal = costoTotalCombustible - montoDescuento;

        
        string mensajeGasto = $"Una flota de {cantidadDeUnidades} unidades trabajando durante {periodoDeDias} días implicará un gasto de {costoTotalCombustible:F2} pesos en concepto de combustible.";
        Debug.Log(mensajeGasto);

        if (aplicaDescuento)
        {
            string mensajeDescuento = $"Se aplica un descuento de {montoDescuento:F2} pesos. El costo final con descuento es de {costoFinal:F2} pesos.";
            Debug.Log(mensajeDescuento);
        }
        else
        {
            Debug.Log("No se aplica descuento, ya que no se superaron los 100 litros de combustible.");
        }
    }
}

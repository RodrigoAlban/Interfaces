 O cliente deve ter o maior leque possível de métodos de pagamento, para garantir a compra independente de seu método favorito.

### Exemplo básico de implementação:

```
switch(metodoDePagamento){
    debito:
        pagamentoDebito();
        break;
    credito:
        pagamentoCredito();
        break;
    pix:
        pagamentoPix();
        break;
    paypal:
        pagamentoPaypal();
        break;
}
```

### Fluxo: 
    Recebe o método escolhido → switch(credito) então
    "pagamentoCredito".

### Dores atuais: 
    A cada novo meio de pagamento será necessário adicionar novos casos no switch.

### Como melhorar: 
    Criar uma interface de pagamentos, aonde serão manejados todos os pagamentos, aonde esta recebe apenas o cliente e o valor da conta, terceirizando esta obrigatoriedade.


protected abstract class pagamento-base
{
 protected decimal taxa (get ;)
 protected decimal valor (get; )
 protected valoPagamento (get;)

protected pagamentoFormato {
    valorPagamento - cobrança
}

}


```
switch(metodoDePagamento){
    debito:
        sealed override.pagamentoFormato();
        break;
    credito:
        sealed override.pagamentoFormato();
        break;
    pix:
        sealed override.pagamentoFormato();
        break;
    paypal:
        sealed override.pagamentoFormato();
        break;
}
```

# melhorias
o programador fica com seu trabalho  mais fácil de puxar os métodos e implementar, não é preciso escrever um novo pagamento para debito,credito,pix ou paypal. O cliente fica com uma aplicação flexível o que mostra a utilização dos príncipios liskov
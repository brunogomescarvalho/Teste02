
export interface IEquipamento {
    id?: number,
    nome: string,
    preco: number,
    nrSerie: string,
    dataFabricacao: Date,
    fabricante: string
}

export interface IChamado {
    id?: number,
    titulo: string,
    descricao: string,
    equipamento: IEquipamento,
    dataAbertura: Date,
    diasEmAberto?: number
}
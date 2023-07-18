import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

const MDI = 'api/keeps'

class KeepsService {
    async getKeepsFromApi(){
        logger.log('getKeepsFromApi()')
        const res = await api.get(MDI)
        logger.log(res.data)
        AppState.keeps = res.data.map( k => new Keep(k) )
        logger.log(AppState.keeps)
    }
    async getKeepById(id){
        logger.log(`getKeepsFromApi(${id})`)
        const res = await api.get(MDI + `/${id}`)
        logger.log(res.data)
        AppState.activeKeep = new Keep(res.data)
        logger.log(AppState.activeKeep)
    }
}

export const keepsService = new KeepsService()
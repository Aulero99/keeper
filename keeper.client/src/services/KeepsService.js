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
}

export const keepsService = new KeepsService()
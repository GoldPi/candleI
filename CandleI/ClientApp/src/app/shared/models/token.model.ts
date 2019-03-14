

export interface Token{
    access_token: string;
    token_type: string;
    expires_in: number;
    userName: string,
    _issued?: Date,
    _expires?: Date
}

export namespace Token{
    

    export function Save( Token:Token) {
    localStorage.setItem('auth',JSON.stringify(Token))
  }

  export function LoggedUser():boolean{
      const auth=localStorage.getItem('auth')
        console.log( auth)
     return auth!=undefined&&auth!=null
  }
    export function LogOut(){
        localStorage.removeItem('auth')
    }
}
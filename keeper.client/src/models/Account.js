export class Profile {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg || 'https://wallpapercave.com/wp/wp2919318.jpg'
    // TODO add additional properties if needed
  }
}

export class Account extends Profile{
  constructor(data){
    super(data)
    this.email = data.email
  }
  
}

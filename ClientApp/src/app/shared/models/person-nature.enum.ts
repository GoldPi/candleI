export enum PersonNature {
  Guest,
  Host
}

export namespace PersonNature {

  export function values() {
    return Object.keys(PersonNature).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    );
  }

  export function value(e: PersonNature) {
    const returnobject = Object.keys(PersonNature).filter(
      (type) => e == (<any>type)
    );
    return (PersonNature[parseInt(returnobject[0])]).replace('_', ' ');
  }
}

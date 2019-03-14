export enum EventType {
  NOT_SELECTED = 0,
  BIRTHDAY = 1,
  ANNIVERSARY = 2,
  INNOGRATION = 3,
  GHRIH_PARWESH = 4,
  CHATTI = 5,
  MUNDAL = 6,
  BABY_SHOWER = 7,
  MIRRAGE = 8,
  ENGAGEMENT = 9,
  RECEPTION = 10,
  PRODUCT_LAUNCH = 11
}
export namespace EventType {

  export function values() {
    return Object.keys(EventType).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    );
  }

  export function value(e: EventType) {
    const returnobject = Object.keys(EventType).filter(
      (type) => e == (<any>type)
    );
    return (EventType[parseInt(returnobject[0])]).replace('_', ' ')
  }
}

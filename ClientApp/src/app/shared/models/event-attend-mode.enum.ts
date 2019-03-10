export enum EventAttendMode {
  Online,
  Offline
}

export namespace EventAttendMode {

  export function values() {
    return Object.keys(EventAttendMode).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    );
  }

  export function value(e: EventAttendMode) {
    const returnobject = Object.keys(EventAttendMode).filter(
      (type) => e == (<any>type)
    );
    return (EventAttendMode[parseInt(returnobject[0])]).replace('_', ' ');
  }
}

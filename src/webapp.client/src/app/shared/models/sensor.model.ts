import { Device } from "./device.model";

export interface Sensor {
    id: number;
    name: string;
    measurments: string;
    kind: number;
    deviceId: number;
}

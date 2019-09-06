import { IConnection } from "./IConnection";
import { IHttpConnectionOptions } from "./IHttpConnectionOptions";
import { HttpTransportType, TransferFormat } from "./ITransport";
/** @private */
export interface INegotiateResponse {
    connectionId?: string;
    availableTransports?: IAvailableTransport[];
    url?: string;
    accessToken?: string;
    error?: string;
}
/** @private */
export interface IAvailableTransport {
    transport: keyof typeof HttpTransportType;
    transferFormats: Array<keyof typeof TransferFormat>;
}
/** @private */
export declare class HttpConnection implements IConnection {
    private connectionState;
    private baseUrl;
    private readonly httpClient;
    private readonly logger;
    private readonly options;
    private transport?;
    private startPromise?;
    private stopError?;
    private accessTokenFactory?;
    readonly features: any;
    onreceive: ((data: string | ArrayBuffer) => void) | null;
    onclose: ((e?: Error) => void) | null;
    constructor(url: string, options?: IHttpConnectionOptions);
    start(): Promise<void>;
    start(transferFormat: TransferFormat): Promise<void>;
    send(data: string | ArrayBuffer): Promise<void>;
    stop(error?: Error): Promise<void>;
    private startInternal;
    private getNegotiationResponse;
    private createConnectUrl;
    private createTransport;
    private constructTransport;
    private resolveTransport;
    private isITransport;
    private changeState;
    private stopConnection;
    private resolveUrl;
    private resolveNegotiateUrl;
}

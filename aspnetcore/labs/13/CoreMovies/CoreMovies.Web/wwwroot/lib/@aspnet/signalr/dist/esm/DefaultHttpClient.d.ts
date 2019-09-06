import { HttpClient, HttpRequest, HttpResponse } from "./HttpClient";
import { ILogger } from "./ILogger";
/** Default implementation of {@link @aspnet/signalr.HttpClient}. */
export declare class DefaultHttpClient extends HttpClient {
    private readonly httpClient;
    /** Creates a new instance of the {@link @aspnet/signalr.DefaultHttpClient}, using the provided {@link @aspnet/signalr.ILogger} to log messages. */
    constructor(logger: ILogger);
    /** @inheritDoc */
    send(request: HttpRequest): Promise<HttpResponse>;
    getCookieString(url: string): string;
}
